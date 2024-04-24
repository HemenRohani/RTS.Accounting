import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';
import { AddInvoiceDocumentComponent } from './add-invoice-document/add-invoice-document.component';
import { AddIndependentCreditNoteComponent } from './add-independent-credit-note/add-independent-credit-note.component';
import { AddDependentCreditNoteComponent } from './add-dependent-credit-note/add-dependent-credit-note.component';
import { DocumentsListComponent } from './documents-list/documents-list.component';

@NgModule({
  declarations: [
    AppComponent,
    AddInvoiceDocumentComponent,
    AddIndependentCreditNoteComponent,
    AddDependentCreditNoteComponent,
    DocumentsListComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
