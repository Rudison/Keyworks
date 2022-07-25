/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PainelCardsService } from './PainelCards.service';

describe('Service: PainelCards', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PainelCardsService]
    });
  });

  it('should ...', inject([PainelCardsService], (service: PainelCardsService) => {
    expect(service).toBeTruthy();
  }));
});
