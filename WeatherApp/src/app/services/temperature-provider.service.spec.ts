import { TestBed } from '@angular/core/testing';

import { TemperatureProviderService } from './temperature-provider.service';

describe('TemperatureProviderService', () => {
  let service: TemperatureProviderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TemperatureProviderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
