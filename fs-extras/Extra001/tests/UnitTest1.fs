module Extra001.Tests

open System
open NUnit.Framework
open Extra001

[<TestFixture>]
type TestClass () =

    [<Test>]
    member this.CatsFishZero() =
        let expected = 0
        let actual = Extra001.getCatsFish 44 
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.CatsFishTwo() =
        let expected = 2
        let actual = Extra001.getCatsFish 2 
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.CatsFishNotMoreThanThree() =
        let expected = 4
        let actual = Extra001.getCatsFish 88 
        Assert.That(actual, Is.LessThan(expected))

    [<Test>]
    member this.CatsHaveMore1() =
        let input = 6
        let cat = Extra001.getCatsFish input
        let bear = Extra001.getBearsFish input 
        Assert.That(bear, Is.LessThan(cat))

    [<Test>]
    member this.CatsHaveMore2() =
        let input = 7
        let cat = Extra001.getCatsFish input
        let bear = Extra001.getBearsFish input 
        Assert.That(bear, Is.LessThan(cat))

    [<Test>]
    member this.CatsDontHaveMore1() =
        let input = 5
        let cat = Extra001.getCatsFish input
        let bear = Extra001.getBearsFish input 
        Assert.That(cat, Is.LessThanOrEqualTo(bear))

    [<Test>]
    member this.CatsDontHaveMore2() =
        let input = 8
        let cat = Extra001.getCatsFish input
        let bear = Extra001.getBearsFish input 
        Assert.That(cat, Is.LessThanOrEqualTo(bear))