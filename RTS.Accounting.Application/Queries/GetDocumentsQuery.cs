using MediatR;
using RTS.Accounting.Application.Dtos;
using RTS.Accounting.Domain.Enums;
using RTS.Accounting.Domain.Repositories;

namespace RTS.Accounting.Application.Queries
{
    public record GetDocumentsQuery(DocumentType? Type) : IRequest<List<DocumentDto>>;

    public class GetDocumentsQueryHandler(IDocumentRepository documentRepository) : IRequestHandler<GetDocumentsQuery, List<DocumentDto>>
    {
        private readonly IDocumentRepository _documentRepository = documentRepository;
        public async Task<List<DocumentDto>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
        {
            var documents = await _documentRepository.GetAllAsync(request.Type, cancellationToken);

            return documents.Select(DocumentDto.Map).ToList();
        }

    }
}
