﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BookingProject.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationController : Controller
    {
        public async Task<IActionResult> Index(string city)
        {
            if (!string.IsNullOrEmpty(city))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={city}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "e377acc97emsh8b49d7ff2f70369p1d60f2jsn2c2b95aa1ebb" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<SearchViewModel>>(body);
                    return View(values.ToList());
                }

            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name=istanbul&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "e377acc97emsh8b49d7ff2f70369p1d60f2jsn2c2b95aa1ebb" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<SearchViewModel>>(body);
                    return View(values.ToList());
                }
            }

        }
    }
}