 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44330/',
  redirectUri: baseUrl,
  clientId: 'Synapse_App',
  responseType: 'code',
  scope: 'offline_access Synapse',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Synapse',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44330',
      rootNamespace: 'Synapse',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
