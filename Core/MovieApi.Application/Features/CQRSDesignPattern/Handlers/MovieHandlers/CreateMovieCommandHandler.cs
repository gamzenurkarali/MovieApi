﻿using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handle(CreateMovieCommand command)
        {
            _context.Movies.Add(new Movie
            {
                Title = command.Title,
                CoverImageUrl = command.CoverImageUrl,
                CreatedYear = command.CreatedYear,
                Description = command.Description,
                Duration = command.Duration,
                Rating = command.Rating,
                ReleasedDate = command.ReleasedDate,
                Status = command.Status,

            });
            await _context.SaveChangesAsync();
        }
    }
}
