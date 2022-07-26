/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PaineisService } from './Paineis.service';

describe('Service: Paineis', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PaineisService]
    });
  });

  it('should ...', inject([PaineisService], (service: PaineisService) => {
    expect(service).toBeTruthy();
  }));
});
