﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using MyAppBackend.Services.PostService;
using MyAppBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseController
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService ?? throw new ArgumentNullException(nameof(postService));
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await postService.GetPosts(GetCurrentUserID());
            return Ok(posts);
        }

        [HttpGet("posts/{UserID}")]
        public async Task<IActionResult> GetUserPosts(int UserID)
        {
            List<PostViewModel> posts = await postService.GetUserPosts(UserID);
            return Ok(posts);
        }

        [HttpGet("{PostID}")]
        public async Task<IActionResult> GetPost(int PostID)
        {
            PostViewModel post = await postService.GetPost(GetCurrentUserID(), PostID);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            PostViewModel createdPost = await postService.CreatePost(post, GetCurrentUserID());
            return Ok(createdPost);
        }

        [HttpPut("update/{PostID}")]
        public async Task<IActionResult> UpdatePost([FromBody] string body, int PostID)
        {
            await postService.UpdatePost(body, GetCurrentUserID(), PostID);
            return Ok();
        }

        [HttpDelete("delete/{PostID}")]
        public async Task<IActionResult> DeletePost(int PostID)
        {
            await postService.DeletePost(PostID);
            return Ok();
        }

        [HttpPost("vote/{PostID}")]
        public async Task<IActionResult> VotePost([FromBody] bool vote, int PostID)
        {
            await postService.VotePost(GetCurrentUserID(), PostID, vote);
            return Ok();
        }
    }
}
