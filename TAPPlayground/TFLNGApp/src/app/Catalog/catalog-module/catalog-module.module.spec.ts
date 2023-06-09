import { CatalogModuleModule } from './catalog-module.module';

describe('CatalogModuleModule', () => {
  let catalogModuleModule: CatalogModuleModule;

  beforeEach(() => {
    catalogModuleModule = new CatalogModuleModule();
  });

  it('should create an instance', () => {
    expect(catalogModuleModule).toBeTruthy();
  });
});
