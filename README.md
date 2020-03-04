# PipelineFlux

## Descrição

Este projeto é uma implementação do padrão ["Chain of Responsibility"](https://refactoring.guru/design-patterns/chain-of-responsibility) para aplicações C#.

### IContext

    To be defined

### IMiddleware

    To be defined.

### PipelineBase

    To be defined.

## Exemplo de uso em um teste com [XUnit](https://xunit.net)

```C#
var expectedResult = 2;
var ctx = new Context();
var pipe = new Pipeline(ctx);
IMiddleware<int> middlewareAddOne = BuildAddMiddleware(ctx);
pipe
    .AddStep(middlewareAddOne)
    .AddStep(middlewareAddOne)
    .Execute();
Assert.Equal(expectedResult, pipe.GetResult());
```
