var OpenWeatherAppKey = "b08fa9ed607c8ee09c575207c6701442";

function getWeatherWithZipCode() {
    // 1. Grab city name (or 'zip code') from the input
    var zipcode = $('#zip-code-input').val();

    // 2. Build the OpenWeatherMap API URL
    //    This includes city name + ',BG' and uses 'imperial' units (Fahrenheit)
    var queryString = 'http://api.openweathermap.org/data/2.5/weather?q='
        + zipcode
        + ',BG&appid='
        + OpenWeatherAppKey
        + '&units=imperial';

    // 3. Fetch the data as JSON
    $.getJSON(queryString, function (results) {
        showWeatherData(results);
    }).fail(function (jqXHR) {
        $('#error-msg').show();
        $('#error-msg').text("Error retrieving data. " + jqXHR.statusText);
    });

    // Prevent default form submission
    return false;
}

function showWeatherData(results) {
    // 1. Check if the "weather" array has data
    if (results.weather && results.weather.length) {
        // Hide any previous error message
        $('#error-msg').hide();
        // Show the weather data container
        $('#weather-data').show();

        // 2. Populate UI fields
        //    - Convert Fahrenheit to Celsius: (F - 32) * 5/9
        $('#title').text(results.name);
        $('#temperature').text(((results.main.temp - 32) * 5 / 9).toFixed(1));
        $('#wind').text(results.wind.speed);
        $('#humidity').text(results.main.humidity);

        // If you actually want numeric visibility (in meters or miles),
        // use `results.visibility` instead. For a text condition (e.g. "Clouds"),
        // you can use `results.weather[0].main`.
        $('#visibility').text(results.weather[0].main);

        // 3. Convert sunrise/sunset from UNIX timestamp to local time
        var sunriseDate = new Date(results.sys.sunrise * 1000);
        $('#sunrise').text(sunriseDate.toLocaleTimeString());

        var sunsetDate = new Date(results.sys.sunset * 1000);
        $('#sunset').text(sunsetDate.toLocaleTimeString());
    } else {
        // If no weather data was returned, show an error
        $('#weather-data').hide();
        $('#error-msg').show();
        $('#error-msg').text("Error retrieving data. ");
    }
}
