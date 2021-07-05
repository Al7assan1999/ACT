import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'ACT',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44348',
    redirectUri: baseUrl,
    clientId: 'ACT_App',
    responseType: 'code',
    scope: 'offline_access ACT',
  },
  apis: {
    default: {
      url: 'https://localhost:44348',
      rootNamespace: 'ACT',
    },
  },
} as Environment;
