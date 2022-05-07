import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgModule } from '@angular/core';
import { pipe } from 'rxjs';
import { Toy } from 'src/shared/toy.model';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-toys',
  templateUrl: './toys.component.html',
  styleUrls: ['./toys.component.scss']
})
export class ToysComponent implements OnInit {

  constructor(private http: HttpClient) { }
  loadedToys: Toy[] = [];

  ngOnInit(): void {
    this.onGetToys();
  }

  private onGetToys(){
    this.http.get<{[key: string]: Toy}>('http://localhost:9277/api/Toys')
    .pipe(
      map(responseData => {
      const toyArray: Toy[] = [];
      for(const index in responseData){
        toyArray.push({...responseData[index]});
      }
      return toyArray.sort((n1,n2) => n1.toyId - n2.toyId);
    }))
    .subscribe(toys =>{
      this.loadedToys = toys;
    });
  }
}
