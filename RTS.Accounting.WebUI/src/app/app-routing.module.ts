import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddInvoiceDocumentComponent } from './add-invoice-document/add-invoice-document.component';
import { AddIndependentCreditNoteComponent } from './add-independent-credit-note/add-independent-credit-note.component';
import { AddDependentCreditNoteComponent } from './add-dependent-credit-note/add-dependent-credit-note.component';
import { DocumentsListComponent } from './documents-list/documents-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'DocumentsList', pathMatch: 'full' },
  { path: 'DocumentsList', component: DocumentsListComponent },
  { path: 'AddInvoiceDocument', component: AddInvoiceDocumentComponent },
  { path: 'AddIndependentCreditNote', component: AddIndependentCreditNoteComponent },
  { path: 'AddDependentCreditNote', component: AddDependentCreditNoteComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
