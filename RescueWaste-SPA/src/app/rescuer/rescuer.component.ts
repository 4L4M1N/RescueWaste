import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rescuer',
  templateUrl: './rescuer.component.html',
  styleUrls: ['./rescuer.component.css']
})
export class RescuerComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
    this.router.navigate(['/rescuer/dashboard']);
  }

}
