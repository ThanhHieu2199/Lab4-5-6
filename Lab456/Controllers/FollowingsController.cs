using Lab456.DTOs;
using Lab456.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Lab456.Controllers
{ 
    public class FollowingsController : ApiController
{
    private readonly ApplicationDbContext _dbContext;
    public FollowingsController()
    {
        _dbContext = new ApplicationDbContext();

    }
    [HttpPost]
    public IHttpActionResult Follow(FollowingDto followingDto)
    {
        var userId = User.Identity.GetUserId();
        if(_dbContext.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == followingDto.FolloweeId))

            return BadRequest("The Following already exists!");
        var folowing = new Following
        {
            FollowerId = userId,
            FolloweeId = followingDto.FolloweeId
        };
        _dbContext.Followings.Add(folowing);
        _dbContext.SaveChanges();

        return Ok();
    }
}
}