# 🎧 Emissor de Frequências Binaurais

![.NET Version](https://img.shields.io/badge/.NET-6.0-%23512bd4)
[![Licença MIT](https://img.shields.io/badge/license-MIT-green)](LICENSE)

Aplicação desktop para geração de frequências binaurais (batidas sonoras) que podem auxiliar em estados meditativos, concentração e relaxamento.

## ✨ Funcionalidades
- Geração de ondas binaurais com frequências personalizáveis
- Controle independente para cada ouvido (esquerdo/direito)
- Seletor de formas de onda: Senoidal, Quadrada, Triangular e Dente-de-serra
- Modulação de amplitude para efeitos pulsantes
- Interface intuitiva com controles deslizantes para ajuste fino
- Sistema de presets para configurações populares:
  - Relaxamento profundo (Delta: 1-4 Hz)
  - Meditação (Theta: 4-8 Hz)
  - Concentração (Alpha: 8-14 Hz)
  - Estado alerta (Beta: 14-30 Hz)

## ⚙️ Pré-requisitos
- .NET 6.0 Runtime ([Download](https://dotnet.microsoft.com/download/dotnet/6.0))
- Windows 10/11 ou sistema compatível com .NET MAUI
- Placa de som estéreo

## 🚀 Como Usar
1. Faça o download 
2. Execute `Binaural.exe`
3. Ajuste as frequências:
   - Frequência Base: 100-300 Hz (recomendado)
   - Diferença Binaural: 1-30 Hz (define o efeito cerebral)
4. Selecione a forma de onda desejada
5. Use o controle de volume para ajustar a intensidade
6. Clique em `Iniciar` para começar a emissão

## 🧪 Exemplo de Configuração
```csharp
// Criação de um gerador binaural
var generator = new BinauralGenerator(
    baseFrequency: 150,     // Hz (ouvido esquerdo)
    delta: 10,              // Hz (diferença para ouvido direito)
    waveType: WaveType.Sine,
    amplitude: 0.7
);

// Inicia a emissão
generator.Start();

// Modulação dinâmica (opcional)
generator.ModulateAmplitude(frequency: 0.5, depth: 0.2);