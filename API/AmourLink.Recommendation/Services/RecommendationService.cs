﻿using System.Net;
using AmourLink.Recommendation.Data.Entities;
using AmourLink.Recommendation.DTO;
using AmourLink.Recommendation.Extensions;
using AmourLink.Recommendation.Infrastructure;
using AmourLink.Recommendation.Infrastructure.Pagination;
using AmourLink.Recommendation.Repository;
using AmourLink.Recommendation.Services.Interfaces;
using AmourLink.Recommendation.Specification;
using AutoMapper;

namespace AmourLink.Recommendation.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly HttpContext _context;

        public RecommendationService(IRepository<User> userRepository, IMapper mapper, IHttpContextAccessor accessor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _context = accessor.HttpContext ??
                       throw new InvalidOperationException("HttpContextAccessor does`t have context");
        }


        public async Task<List<MemberDto>> GetPagedFeedAsync(PaginationParams paginationParams, CancellationToken cancellationToken = default)
        {
            var currentUserId = _context.User.GetUserId();
            
            if(currentUserId == Guid.Empty)
                throw new HttpException(HttpStatusCode.Unauthorized);


            var userWithPreferencesAndDetailsSpecification = new UserWithPreferencesAndDetailsSpecification(currentUserId);
            
            var currentUser = await _userRepository.GetFirstOrDefaultAsync(userWithPreferencesAndDetailsSpecification, cancellationToken)
                ?? throw new HttpException(HttpStatusCode.NotFound, $"User with id: {currentUserId} was not found");
            
            if (currentUser.UserDetails?.LastLocation == null)
                throw new HttpException(HttpStatusCode.BadRequest,
                    "Operation failed due to lack of information about the user's last location");

            if (currentUser.UserPreference == null)
                throw new HttpException(HttpStatusCode.InternalServerError,
                    "Required field 'UserPreference' cannot be null");
            
            var userWithProfileSpecification = new UserWithProfileSpecification(currentUser.UserPreference.MaxAge,
                currentUser.UserPreference.MinAge, currentUser.UserDetails.LastLocation.Y,
                currentUser.UserDetails.LastLocation.X, currentUser.UserPreference.DistanceRange,
                currentUser.Rating, currentUserId);
            
            var users = await _userRepository.GetPagedListAsync(userWithProfileSpecification,
                paginationParams.PageNumber, paginationParams.PageSize, cancellationToken);
            
            _context.Response.AddPaginationHeader(users.CurrentPage,
                users.TotalPages, users.PageSize, users.TotalCount);
            
            var userDtos = _mapper.Map<List<MemberDto>>(users);
            
            return userDtos;
        }
    }
}
