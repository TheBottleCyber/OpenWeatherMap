# What is it?
Simple library for getting the weather from api.openweathermap.org

# How register appIdKey
https://openweathermap.org/appid#get

# Quick start
```c#
var client = new OpenWeatherMapClient("yourAppIdKey");
Weather currentWeather = client.GetByCityName("Moscow");
// Find out the current air temperature
var temperature = currentWeather.Temperature.Current;
```

# Find city by your network ip
```c#
var client = new OpenWeatherMapClient("yourAppIdKey");
Weather currentWeather = client.GetByIPGeoLocation();
// Find out the current air temperature
var temperature = currentWeather.Temperature.Current;
```
