using MediatR;
using RTS.Accounting.Application.Dtos;
using RTS.Accounting.Domain.Repositories;

namespace RTS.Accounting.Application.Queries
{
    public record GetDocumentsQuery() : IRequest<List<DocumentDto>>;

    public class GetDocumentsQueryHandler(IDocumentRepository documentRepository) : IRequestHandler<GetDocumentsQuery, List<DocumentDto>>
    {
        private readonly IDocumentRepository _documentRepository = documentRepository;
        public async Task<List<DocumentDto>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
        {
            var documents = await _documentRepository.GetAllAsync();

            return documents.Select(DocumentDto.Map).ToList();
        }

    }
}
