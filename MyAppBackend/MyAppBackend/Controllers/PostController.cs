﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.Services.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IPostService postService;
        public PostController(DataContext context, IPostService postService)
        {
            this.context = context;
            this.postService = postService ?? throw new ArgumentNullException(nameof(postService));
        }
        private int GetCurrentUserID()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userID = claims.Where(p => p.Type == "ID").FirstOrDefault()?.Value;
            return Int32.Parse(userID);
        }

        [HttpGet("posts"), Authorize]
        public List<PostModel> GetPosts()
        {
            var posts = postService.GetPosts(context, GetCurrentUserID());
            return posts;
        }

        [HttpGet("post"), Authorize]
        public IActionResult GetPost()
        {
            return Ok();
        }
    }
}