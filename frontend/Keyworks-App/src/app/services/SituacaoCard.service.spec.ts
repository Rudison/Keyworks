/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SituacaoCardService } from './SituacaoCard.service';

describe('Service: SituacaoCard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SituacaoCardService]
    });
  });

  it('should ...', inject([SituacaoCardService], (service: SituacaoCardService) => {
    expect(service).toBeTruthy();
  }));
});
