import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';


@Component({
  selector: 'app-rescuer',
  templateUrl: './rescuer.component.html',
  styleUrls: ['./rescuer.component.css']
})
export class RescuerComponent implements OnInit {

  constructor(private router: Router,
              public authService: AuthService) { }

  ngOnInit() {
    this.router.navigate(['/rescuer/dashboard']);
  }

}
