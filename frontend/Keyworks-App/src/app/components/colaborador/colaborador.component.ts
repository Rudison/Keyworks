import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Colaborador } from '../../models/Colaborador';
import { ColaboradorService } from '../../services/Colaborador.service';

@Component({
  selector: 'app-colaborador',
  templateUrl: './colaborador.component.html',
  styleUrls: ['./colaborador.component.scss'],
})
export class ColaboradorComponent implements OnInit {
  modalRef?: BsModalRef;

  constructor(
    private colaboradorService: ColaboradorService,
    private modalService: BsModalService,
    private toastr: ToastrService
  ) {}

  public ngOnInit(): void {
    this.getColaboradores();
  }

  public colaboradores: Colaborador[] = [];
  public colaboradoresFiltrados: Colaborador[] = [];

  private _filtroLista: string = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.colaboradoresFiltrados = this.filtroLista
      ? this.filtrarColaboradores(this.filtroLista)
      : this.colaboradores;
  }

  public filtrarColaboradores(filtrarPor: string): Colaborador[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.colaboradores.filter(
      (colaborador: any) =>
        colaborador.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        colaborador.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public getColaboradores(): void {
    const observer = {
      next: (colaboradores: Colaborador[]) => {
        this.colaboradores = colaboradores;
        this.colaboradoresFiltrados = this.colaboradores;
      },
      error: (error: any) => console.log(error),
      complete: () => {},
    };

    this.colaboradorService.getColaboradores().subscribe(observer);
  }

  public insertColaborador(): void {}

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  modalInsert(templateInsert: TemplateRef<any>) {
    this.modalRef = this.modalService.show(templateInsert);
  }

  confirm(): void {
    this.toastr.success('Evento excluido com sucesso', 'Excluido!');
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
