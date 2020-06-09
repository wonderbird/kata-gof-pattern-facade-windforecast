# Wind Forecast

![Build Status Badge](https://github.com/wonderbird/kata-gof-pattern-facade-windforecast/workflows/.NET%20Core/badge.svg)

**Attention**

This kata is under development. I have just begun documenting the idea. Please come back later, after June 9, 2020.

In this kata you implement the Gang Of Four Facade Pattern [[1](#ref-1), [2](#ref-2), [3](#ref-3)].

**Notes**

* In this kata we will use the [OpenWeather API](https://openweathermap.org/api) [[4](#ref-4)]. Please create a free account here [Register for OpenWeather API](https://home.openweathermap.org/users/sign_up). Note that they need some hours to enable your account. **After you received your API key, please store it in the environment variable** `OPENWEATHER_APIKEY`.
* In addition we will use the [Bing Maps API](https://docs.microsoft.com/en-us/bingmaps/rest-services/) [[6](#ref-6)]. Please get your individual API key by following [these instructions](https://docs.microsoft.com/en-us/bingmaps/getting-started/bing-maps-dev-center-help/getting-a-bing-maps-key). **After you received your API key, please store it in the environment variable** `BINGMAPS_APIKEY`.

## Problem Description

An application shall provide the wind forecast in beaufort for a particular day at a given location.

## Hint

- Keep the implementation as minimal as possible in order to keep the kata small. Just fulfill the requirements
- Use TDD. Tests first. Red, Green, Refactor.

## Steps to implement the kata

1. Call the [OpenWeather One Call API](https://openweathermap.org/api/one-call-api) [[5](#ref-5)] to read the windspeed of an arbitrary location for the current day.

2. Allow customizing the forecast location (`lat`, `lon`) and duration (`dt`) by passing the parameters `lat`, `lon`, `dt` and `appid` to the API call. The parameters are described in the [OpenWeather One Call API](https://openweathermap.org/api/one-call-api) [[5](#ref-5)].

3. Create an interface and associated class to transform m/s wind speed to beaufort. Use the table below as a reference.

4. Use the [Bing Maps Find a Location by Query API](https://docs.microsoft.com/en-us/bingmaps/rest-services/locations/find-a-location-by-query) [[7](#ref-7)] to allow specifying the location of the forecast as a string describing the location (e.g. "Amsterdam NL")

5. Create a Facade class `WindForecastService`. The method `GetWindForecast(string location, TimeSpan timeFromNow)` shall return the wind speed in beaufort expected at the `location` at the time `now + timeFromNow`.

## Windspeed: m/s to beaufort conversion

Source: [Windfinder: Wind speed units & wind directions](https://www.windfinder.com/wind/windspeed.htm?) [[8](#ref-8)]

Beaufort | Knots | m/s | km/h | mph | Label
-------- | ----- | --- | ---- | --- | -----
0 | 1 | 0 - 0.2 | 1 | 1 | Calm
1 | 1-3 | 0.3-1.5 | 1-5 | 1-3 | Light Air
2 | 4-6 | 1.6-3.3 | 6-11 | 4-7 | Light Breeze
3 | 7-10 | 3.4-5.4 | 12-19 | 8-12 | Gentle Breeze
4 | 11-15 | 5.5-7.9 | 20-28 | 13-17 | Moderate Breeze
5 | 16-21 | 8.0-10.7 | 29-38 | 18-24 | Fresh Breeze
6 | 22-27 | 10.8-13.8 | 39-49 | 25-30 | strong Breeze
7 | 28-33 | 13.9-17.1 | 50-61 | 31-38 | Near Gale
8 | 34-40 | 17.2-20.7 | 62-74 | 39-46 | Gale
9 | 41-47 | 20.8-24.4 | 75-88 | 47-54 | Severe Gale
10 | 48-55 | 24.5-28.4 | 89-102 | 55-63 | Strong storm
11 | 56-63 | 28.5-32.6 | 103-117 | 64-73 | Violent Storm
12 | 64-71 | >32.7 | >118 | >74 | Hurricane

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

<a name="ref-6">[6]</a> Microsoft: "Bing Maps REST Services", https://docs.microsoft.com/en-us/bingmaps/rest-services/, last visited on Jun. 4, 2020.

<a name="ref-7">[7]</a> Microsoft: "Bing Maps: Find a Location by Query", https://docs.microsoft.com/en-us/bingmaps/rest-services/locations/find-a-location-by-query, last visited on Jun. 4, 2020.

<a name="ref-8">[8]</a> Windfinder.com GmbH & Co. KG: "Wind speed units & wind directions", https://www.windfinder.com/wind/windspeed.htm?, last visited on Jun. 9, 2020.
