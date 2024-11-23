export interface Match {
  invoiceId: number,
  invoiceYukiKey: string,
  invoiceCompanyName: string,
  invoiceCompanyAlias: string,
  invoiceSubject: string,
  invoiceAmount: number,
  invoiceDate: string,
  isExceptionFromRule: boolean,
}
