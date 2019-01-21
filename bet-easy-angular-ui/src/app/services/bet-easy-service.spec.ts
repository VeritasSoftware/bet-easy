import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';

import { BetEasyService } from './bet-easy-service';

describe('Validation Service Tests', () => {
  let betEasyService: BetEasyService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
      declarations: [],
      providers: [BetEasyService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    
  });

  it('Bet Easy Service - returns results', async () => {
   
    //Inject Validation Service
    betEasyService = TestBed.get(BetEasyService);

    var result = betEasyService.get().subscribe(x => {
        var result = x.body;
        
        expect(result.result.length > 0).toBeTruthy();
    });        

  });
}); 