using MediatR;
using Microsoft.AspNetCore.Mvc;
using RTS.Accounting.Application.Commands;
using RTS.Accounting.Application.Dtos;
using RTS.Accounting.Application.Queries;

namespace RTS.Accounting.WebApi.Controllers
{
    [ApiController]
    [Route("/document")]
    public class DocumentController(ILogger<DocumentController> logger, IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        private readonly ILogger<DocumentController> _logger = logger;

        [HttpGet("getDocument")]
        [ProducesResponseType(typeof(DocumentDto), StatusCodes.Status200OK)]
        public async Task<DocumentDto> Get([FromQuery] GetDocumentQuery getDocumentQuery, CancellationToken cancellation)
        {
            return await _mediator.Send(getDocumentQuery, cancellation);
        }

        [HttpGet("getDocuments")]
        [ProducesResponseType(typeof(List<DocumentDto>), StatusCodes.Status200OK)]
        public async Task<List<DocumentDto>> Get([FromQuery] GetDocumentsQuery getDocumentsQuery, CancellationToken cancellation)
        {
            return await _mediator.Send(getDocumentsQuery, cancellation);
        }

        [HttpPost("removeDocument")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Unit> Remove([FromBody] RemoveDocumentCommand removeDocumentCommand, CancellationToken cancellation)
        {
            return await _mediator.Send(removeDocumentCommand, cancellation);
        }

        [HttpPost("addInvoiceDocument")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Unit> AddInvoiceDocument([FromBody] AddInvoiceDocumentCommand addInvoiceDocumentCommand, CancellationToken cancellation)
        {
            return await _mediator.Send(addInvoiceDocumentCommand, cancellation);
        }

        [HttpPost("addIndependentCreditNote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Unit> AddInvoiceDocument([FromBody] AddIndependentCreditNoteCommand addIndependentCreditNoteCommand, CancellationToken cancellation)
        {
            return await _mediator.Send(addIndependentCreditNoteCommand, cancellation);
        }

        [HttpPost("addDependentCreditNote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Unit> AddInvoiceDocument([FromBody] AddDependentCreditNoteCommand addDependentCreditNoteCommand, CancellationToken cancellation)
        {
            return await _mediator.Send(addDependentCreditNoteCommand, cancellation);
        }


    }
}
