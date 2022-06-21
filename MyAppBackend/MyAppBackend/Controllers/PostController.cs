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
            var posts = postService.GetPosts(GetCurrentUserID());
            return Ok(posts);
        }

        [HttpGet("{id}"), Authorize]
        public IActionResult GetPost(int PostID)
        {
            var post = postService.GetPost(GetCurrentUserID(), PostID);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost, Authorize]
        public PostViewModel CreatePost([FromBody] Post post, int PostID)
        {
            var createdPost = postService.CreatePost(post, GetCurrentUserID());
            return createdPost;
        }

        [HttpPut("update/{id}"), Authorize]
        public IActionResult UpdatePost([FromBody] Post post, int PostID)
        {
            var flag = postService.UpdatePost(post, GetCurrentUserID(), PostID);
            return Ok();
        }

        [HttpDelete("delete/{id}"), Authorize]
        public IActionResult DeletePost(int PostID)
        {
            postService.DeletePost(GetCurrentUserID(), PostID);
            return Ok();
        }

        [HttpPost("upvote/{id}"), Authorize]
        public IActionResult UpvotePost(int PostID)
        {
            postService.UpvotePost(GetCurrentUserID(), PostID);
            return Ok();
        }

        [HttpPost("downvote/{id}"), Authorize]
        public IActionResult Downvote(int PostID)
        {
            postService.DownvotePost(GetCurrentUserID(), PostID);
            return Ok();
        }
    }
}
