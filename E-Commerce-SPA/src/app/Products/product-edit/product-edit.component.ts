import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/_Models/product';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
product:Product;
@ViewChild('productEdit') productEdit:NgForm;

  constructor(private route:ActivatedRoute,private sevice:ProductService,private alertify:AlertifyService) { }

  ngOnInit(): void{
    this.route.data.subscribe(
      data=>{this.product=data['product']});
  }
  updateProduct(){
    this.sevice.updateproduct(this.product.id,this.product).subscribe(
      ()=>{
        this.alertify.success('Updated Is Done');
        this.productEdit.reset(this.product);
      },
      err=>{this.alertify.error(err);}
    )
    
  }
}
