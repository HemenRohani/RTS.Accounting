import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-invoice-document',
  templateUrl: './add-invoice-document.component.html',
  styleUrl: './add-invoice-document.component.css'
})

export class AddInvoiceDocumentComponent implements OnInit {
  addInvoiceDocumentForm: invoiceDocumentForm = new invoiceDocumentForm();

  @ViewChild("invoiceDocumentForm")
  invoiceDocumentForm!: NgForm;

  isSubmitted: boolean = false;

  constructor(private router: Router, private http: HttpClient, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  AddInvoiceDocument(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.http.post('/document/addInvoiceDocument', this.addInvoiceDocumentForm).subscribe(async data => {
        this.toastr.success("Succesfuly Added.");
        setTimeout(() => {
          this.router.navigate(['/Home']);
        }, 500);
      },
        async error => {
          this.toastr.error("Error in adding.");
        });
    }
  }

}

export class invoiceDocumentForm {
  Number: string = "";
  ExternalInvoiceNumber: string = "";
  Status: number = 0;
  TotalAmount: number = 0;
}
