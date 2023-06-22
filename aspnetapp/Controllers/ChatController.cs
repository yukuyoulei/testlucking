#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnetapp;
using System.Text.Encodings.Web;

namespace aspnetapp.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        // GET: api/count
        [HttpGet]
        public async Task<string> Chat(string prompt)
        {
            return await RequestChat(prompt);
        }
        const string reqUrl = "43.143.230.2";
        static HttpClient s_client = new();
        static async Task<string> RequestChat(string text)
        {
            var url = $"http://{reqUrl}/api/OpenAI/Chat?prompt={UrlEncoder.Default.Encode(text)}";
            var response = await s_client.GetAsync($"{url}");
            var resp = await response.Content.ReadAsStringAsync();
            return resp.Trim();
        }

    }
}
