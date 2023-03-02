/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CarGuessComponent } from './car-guess.component';

describe('CarGuessComponent', () => {
  let component: CarGuessComponent;
  let fixture: ComponentFixture<CarGuessComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarGuessComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarGuessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
