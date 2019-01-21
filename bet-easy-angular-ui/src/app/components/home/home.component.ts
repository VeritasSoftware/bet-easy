import { Component, OnInit } from '@angular/core';
import { BetEasyService } from '../../services/bet-easy-service';
import { BetEasyResponse, BetEasyItem, EventType } from '../../models/models';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public eventType =  EventType;
  private items: BetEasyItem[]

  constructor(private service: BetEasyService) { }

  ngOnInit() {
    this.service.get().subscribe(results => {
      if (results != null && results.body != null) {
        this.items = results.body.result;
      }      
    });    
  }

}
