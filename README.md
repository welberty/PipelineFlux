# PipelineFlux

## Description

This project is an implementation of the ["Chain of Responsibility"](https://refactoring.guru/design-patterns/chain-of-responsibility) pattern for applications created in C#.

### IContext

    To be defined

### IMiddleware

    To be defined.

### PipelineBase

    To be defined.

## Example of use in a test builded with [XUnit](https://xunit.net)

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
