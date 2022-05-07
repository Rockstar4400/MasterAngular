import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Toy } from 'src/shared/toy.model';
import {Router} from "@angular/router"

@Component({
  selector: 'app-toy',
  templateUrl: './toy.component.html',
  styleUrls: ['./toy.component.scss']
})
export class ToyComponent implements OnInit{

constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(toyData: Toy){
    this.http.post<{toyName: string}>("http://localhost:9277/api/Toys",toyData)
    .subscribe((resposeData) => {
      this.router.navigate([''])
    });
  }

  onCancel(){
    this.router.navigate(['']);
  }

}
