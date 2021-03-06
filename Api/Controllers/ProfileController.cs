﻿using Api.Entities;
using Api.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Api.Controllers
{
    [CustomAuthorize]
    public class ProfileController : BaseApiController
    {
        private readonly IRepository<Profile> _profileRepository;

        public ProfileController(IRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<IEnumerable<Profile>> GetAll()
        {
            return await _profileRepository.GetAllAsync();
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var s = await _profileRepository.GetByIdAsync(id);
            if (s == null)
                return NotFound();
            return Ok(s);
        }

        public async Task<IHttpActionResult> Post([FromBody]Profile value)
        {
            value.CreatedOnUtc = DateTime.UtcNow;
            value.UpdatedOnUtc = DateTime.UtcNow;

            var profile = await _profileRepository.InsertAsync(value);
            return CreatedAtRoute("DefaultApi", new { profile.Id }, profile);
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            await _profileRepository.DeleteByIdAsync(id);
            return Ok();
        }

        public async Task<OkResult> Patch([FromBody]Profile s)
        {
            await _profileRepository.UpdateAsync(s);
            return Ok();
        }
    }
}