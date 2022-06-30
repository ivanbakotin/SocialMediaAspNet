﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using MyAppBackend.Services.PostService;
using MyAppBackend.ViewModels;
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
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService ?? throw new ArgumentNullException(nameof(postService));
        }

        private int GetCurrentUserID()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userID = claims.Where(p => p.Type == "ID").FirstOrDefault()?.Value;
            return Int32.Parse(userID);
        }

        [HttpGet, Authorize]
        public IActionResult GetPosts()
        {
            List<PostViewModel> posts = postService.GetPosts(GetCurrentUserID());
            return Ok(posts);
        }

        [HttpGet("posts/{id}"), Authorize]
        public IActionResult GetUserPosts(int id)
        {
            List<PostViewModel> posts = postService.GetUserPosts(id);
            return Ok(posts);
        }

        [HttpGet("{id}"), Authorize]
        public IActionResult GetPost(int id)
        {
            PostViewModel post = postService.GetPost(GetCurrentUserID(), id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost, Authorize]
        public IActionResult CreatePost([FromBody] Post post)
        {
            PostViewModel createdPost = postService.CreatePost(post, GetCurrentUserID());
            return Ok(createdPost);
        }

        [HttpPut("update/{id}"), Authorize]
        public IActionResult UpdatePost([FromBody] string body, int id)
        {
            postService.UpdatePost(body, GetCurrentUserID(), id);
            return Ok();
        }

        [HttpDelete("delete/{id}"), Authorize]
        public IActionResult DeletePost(int id)
        {
            postService.DeletePost(GetCurrentUserID(), id);
            return Ok();
        }

        [HttpPost("vote/{id}"), Authorize]
        public IActionResult VotePost([FromBody] bool vote, int id)
        {
            postService.VotePost(GetCurrentUserID(), id, vote);
            return Ok();
        }
    }
}
