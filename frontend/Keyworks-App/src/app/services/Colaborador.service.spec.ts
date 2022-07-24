/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ColaboradorService } from './Colaborador.service';

describe('Service: Colaborador', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ColaboradorService]
    });
  });

  it('should ...', inject([ColaboradorService], (service: ColaboradorService) => {
    expect(service).toBeTruthy();
  }));
});
