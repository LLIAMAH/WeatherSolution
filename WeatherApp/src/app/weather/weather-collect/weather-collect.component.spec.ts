import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherCollectComponent } from './weather-collect.component';

describe('WeatherCollectComponent', () => {
  let component: WeatherCollectComponent;
  let fixture: ComponentFixture<WeatherCollectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeatherCollectComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeatherCollectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
