import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/_models/product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
products:Product[];
  constructor(private rout:ActivatedRoute) { }

  ngOnInit() {
    this.rout.data.subscribe(
      data=>{this.products=data['products']}
    )
  }

}
