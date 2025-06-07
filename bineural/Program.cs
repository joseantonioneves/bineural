using NAudio.Wave;
using System;

namespace BinauralFrequencies
{
    class Program
    {
        static void Main(string[] args)
        {
            // Defina as frequências para cada ouvido
            double freqLeft = 300.0;  // Hz
            double freqRight = 310.0;  // Hz

            // Taxa de amostragem e tempo de reprodução
            Random random = new Random();
            do
            {
                int minValue = 40000;
                int maxValue = 50000;
                int randomValue = random.Next(minValue, maxValue);
                int sampleRate = randomValue;  // Hz
                double duration = 1.0;  // segundos

                Console.WriteLine("randomValue: {0}", randomValue);

                int samples = (int)(sampleRate * duration);
                float[] leftChannel = new float[samples];
                float[] rightChannel = new float[samples];

                // Gere os sinais para cada ouvido
                for (int i = 0; i < samples; i++)
                {
                    double time = (double)i / sampleRate;

                    // Harmônicos para o ouvido esquerdo
                    leftChannel[i] = (float)(0.5 * Math.Sin(2 * Math.PI * freqLeft * time) +
                                             0.25 * Math.Sin(2 * Math.PI * 2 * freqLeft * time) +
                                             0.125 * Math.Sin(2 * Math.PI * 3 * freqLeft * time));

                    // Harmônicos para o ouvido direito
                    rightChannel[i] = (float)(0.5 * Math.Sin(2 * Math.PI * freqRight * time) +
                                              0.25 * Math.Sin(2 * Math.PI * 2 * freqRight * time) +
                                              0.125 * Math.Sin(2 * Math.PI * 3 * freqRight * time));
                }

                // Combine em um sinal estéreo e converta para bytes
                var stereo = new float[samples * 2];
                byte[] byteArray = new byte[stereo.Length * 4];
                for (int i = 0; i < samples; i++)
                {
                    stereo[2 * i] = leftChannel[i];
                    stereo[2 * i + 1] = rightChannel[i];
                }

                Buffer.BlockCopy(stereo, 0, byteArray, 0, byteArray.Length);

                // Reproduza o som
                var waveFormat = new WaveFormat(sampleRate, 2);
                var waveProvider = new BufferedWaveProvider(waveFormat)
                {
                    BufferLength = byteArray.Length,
                    DiscardOnBufferOverflow = true
                };

                waveProvider.AddSamples(byteArray, 0, byteArray.Length);

                using (var waveOut = new WaveOutEvent())
                {
                    waveOut.Init(waveProvider);
                    waveOut.Play();
                    while (waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }

            } while (true);            
        }
    }
}
