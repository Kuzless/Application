import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { OnInit, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent implements OnInit, OnDestroy {
  readonly logoUrl: string = '';
  readonly logoFormat: string = '.png';
  readonly logoName: string = 'logo';

  constructor() {
    console.log('Created');
  }

  ngOnInit(): void {
    console.log('Initialized');
  }

  ngOnDestroy(): void {
    console.log('Destroyed');
  }
}
