import { Component, OnInit } from '@angular/core';
import { ProductManagerService } from './Service/admin.service';
import { NotifierService } from 'angular-notifier';
import { NgxSpinnerService } from 'ngx-spinner';
import {NgxSpinnerModule} from 'ngx-spinner';
import { ApiResponse } from '../Models/api.response';
import { NgForm } from '@angular/forms';
import { ProductModel } from '../Models/ProductModel';
import { ApiCollectionResponse } from './Models/apiResponse';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {
  model = new ProductModel();
  errorMessage!: string;
  allProducts: Array<ProductModel>;

  constructor(
    private adminService: ProductManagerService,
    private notifier: NotifierService,
    private spinner: NgxSpinnerService) { }

    onSubmit(form: NgForm) {
      this.spinner.show();
      
      if (this.model.isValid() == false) 
      {
        this.notifier.hideAll();
  
        setTimeout(() => {
          this.spinner.hide();
          this.notifier.notify('error', 'Enter all fields!');
        }, 5000);
      } 
      else 
      {
        this.adminService.addProduct(this.model).subscribe((data: ApiResponse) => {
            if (data.code == 200) {
              this.spinner.hide();
              this.notifier.notify('success', 'Product added!');
            }
          },
          (error) => {
            this.notifier.notify('error', 'Server error');
            this.spinner.hide();
          }
        );
  
        form.resetForm();
      }
    }

  ngOnInit() {
    this.adminService.getAllProducts().subscribe((res: ApiCollectionResponse)=>{
      if(res.isSuccessful){
        this.allProducts = res.data
      }
    })
  }

}
