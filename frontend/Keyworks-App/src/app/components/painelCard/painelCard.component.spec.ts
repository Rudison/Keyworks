/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PainelCardComponent } from './painelCard.component';

describe('PainelCardComponent', () => {
  let component: PainelCardComponent;
  let fixture: ComponentFixture<PainelCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PainelCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PainelCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
