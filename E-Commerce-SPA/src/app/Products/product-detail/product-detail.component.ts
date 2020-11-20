import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { Product } from 'src/app/_models/product';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
product:Product;
galleryOptions: NgxGalleryOptions[];
galleryImages: NgxGalleryImage[];
  constructor(private route:ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(
      data=>{this.product=data['product']}
    )

    //Gallary
    this.galleryOptions=[{
      width:'400px',height:'500px',imagePercent:100,thumbnailsColumns:4,
      imageAnimation:NgxGalleryAnimation.Slide,preview:false
    }]

    this.galleryImages=this.getImages();
  }

  getImages(){
    const imageUrls=[];
    for(let i =0;i<this.product.photos.length;i++){
      imageUrls.push({
        small:this.product.photos[i].url,
        medium:this.product.photos[i].url,
        big:this.product.photos[i].url,
      })
    };
    return imageUrls;
  }
    

    
}
