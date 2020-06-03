# Wind Forecast

![Build Status Badge](https://github.com/wonderbird/kata-gof-pattern-facade-windforecast/workflows/.NET%20Core/badge.svg)

**Attention**

This kata is under development. I have just begun documenting the idea. Please come back later, after June 9, 2020.

In this kata you implement the Gang Of Four Facade Pattern [[1](#ref-1), [2](#ref-2), [3](#ref-3)].

**Note**

In this kata we will use the [OpenWeather API](https://openweathermap.org/api) [[4](#ref-4)]. Please create a free account here [Register for OpenWeather API](https://home.openweathermap.org/users/sign_up). Note that they need some hours to enable your account.

## Problem Description

An application shall provide the wind forecast in beaufort for a particular day at a given location.

## Hint

- Keep the implementation as minimal as possible in order to keep the kata small. Just fulfill the requirements
- Use TDD. Tests first. Red, Green, Refactor.

## Requirements

1. Call the [OpenWeather One Call API](https://openweathermap.org/api/one-call-api) [[5](#ref-5)] to read a weather forcast for the upcoming five days.

## Finishing Touches

- Avoid duplicated code (use `tools\dupfinder.bat`).
- Fix all static code analysis warnings.
- Check the Cyclomatic Complexity of your source code files. For me, the most complex class has a value of (9 - EventAggregator) and the most complex method has a value of (4 - EventAggregator.Publish). See Visual Studio -> Analyze -> Calculate Code Metrics.

## References

<a name="ref-1">[1]</a> David Starr and others: "Facade" in "Pluralsight: Design Patterns Library", https://www.pluralsight.com/courses/patterns-library, last visited on Jun. 2, 2020.

<a name="ref-2">[2]</a> Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides: "Design Patterns: Elements of Reusable Object-Oriented Software", Addison Wesley, 1994, pp. 151ff, [ISBN 0-201-63361-2](https://en.wikipedia.org/wiki/Special:BookSources/0-201-63361-2).

<a name="ref-3">[3]</a> Wikipedia: "Facade Pattern", https://en.wikipedia.org/wiki/Facade_pattern, last visited on Jun. 2, 2020.

<a name="ref-4">[4]</a> OpenWeather Ltd.: "Open Weather API", https://openweathermap.org/api, last visited on Jun. 3, 2020.

<a name="ref-5">[5]</a> OpenWeather Ltd.: "One Call API", https://openweathermap.org/api/one-call-api, last visited on Jun. 3, 2020.
