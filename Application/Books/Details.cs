using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Books
{
    public class Details
    {


        public class Query : IRequest<Book>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Book>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Book> Handle(Query request, CancellationToken cancellationToken)
            {
                var book = await _context.books.FindAsync(request.Id);
                return book;
            }
        }

    }
}