import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'PaintNet';
  products: any[];

  constructor(private http: HttpClient ){}

  ngOnInit(): void {
   this.http.get('http://localhost:44333/api/Products').subscribe((response: any) => {

     this.products = response.data;
   }, error => {
     console.log(error)   
    });
  
  }
}
