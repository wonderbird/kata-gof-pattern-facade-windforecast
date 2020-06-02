# IRC

**Attention**

This kata is under development. I have just begun documenting the idea. Please come back later, after June 9, 2020.

In this kata you implement the Gang Of Four Facade Pattern [[1](#ref-1), [2](#ref-2), [3](#ref-3)].

## Problem Description

An application shall provide the wind forecast in beaufort for a particular day at a given location.

## Hint

- Keep the implementation as minimal as possible in order to keep the kata small. Just fulfill the requirements
- Use TDD. Tests first. Red, Green, Refactor.

## Requirements

## Finishing Touches

- Avoid duplicated code (use `tools\dupfinder.bat`).
- Fix all static code analysis warnings.
- Check the Cyclomatic Complexity of your source code files. For me, the most complex class has a value of (9 - EventAggregator) and the most complex method has a value of (4 - EventAggregator.Publish). See Visual Studio -> Analyze -> Calculate Code Metrics.

## References

<a name="ref-1">[1]</a> David Starr and others: "Facade" in "Pluralsight: Design Patterns Library", https://www.pluralsight.com/courses/patterns-library, last visited on Jun. 2, 2020.

<a name="ref-2">[2]</a> Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides: "Design Patterns: Elements of Reusable Object-Oriented Software", Addison Wesley, 1994, pp. 151ff, [ISBN 0-201-63361-2](https://en.wikipedia.org/wiki/Special:BookSources/0-201-63361-2).

<a name="ref-3">[3]</a> Wikipedia: "Facade Pattern", https://en.wikipedia.org/wiki/Facade_pattern, last visited on Jun. 2, 2020.

<a name="ref-4">[4]</a> OpenWeather: "Wheather API", https://openweathermap.org/api, last visited on Jun. 2, 2020.
