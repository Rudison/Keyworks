/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { StatusCardService } from './StatusCard.service';

describe('Service: StatusCard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [StatusCardService]
    });
  });

  it('should ...', inject([StatusCardService], (service: StatusCardService) => {
    expect(service).toBeTruthy();
  }));
});
