import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColaboradorDetalheComponent } from './colaborador-detalhe.component';

describe('ColaboradorDetalheComponent', () => {
  let component: ColaboradorDetalheComponent;
  let fixture: ComponentFixture<ColaboradorDetalheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ColaboradorDetalheComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ColaboradorDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
