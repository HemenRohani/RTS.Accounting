using MediatR;

namespace RTS.Accounting.Application.Commands.Document.AddDocument
{
    public record AddDocumentCommand(string Title) : IRequest<Unit>;
}
