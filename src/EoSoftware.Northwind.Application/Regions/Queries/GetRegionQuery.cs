using MediatR;
using Microsoft.EntityFrameworkCore;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class GetRegionQuery : IRequest<RegionDto?>
{
    public short Id { get; set; }

    public class Handler : IRequestHandler<GetRegionQuery, RegionDto?>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<RegionDto?> Handle(GetRegionQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<Region>()
                .Where(r => r.RegionId == request.Id)
                .Select(RegionDto.Projection)
                .FirstOrDefaultAsync();
        }
    }
}
