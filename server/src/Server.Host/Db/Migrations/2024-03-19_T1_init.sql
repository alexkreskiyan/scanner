create table document_type_configurations (id uuid not null primary key, type text not null);

create table document_field_configurations (
    id uuid not null primary key,
    type text not null,
    label text not null,
    data_type text not null
);

create table document_page_configurations (id uuid not null primary key, type text not null);

create table applications (
    id uuid not null primary key,
    status smallint not null,
    document_types jsonb not null,
    files jsonb not null
);

create table documents (
    id uuid not null primary key,
    application_id uuid not null,
    type_id uuid not null,
    constraint fk_documents_applications_application_id foreign KEY (application_id) references applications (id) on delete RESTRICT,
    constraint fk_documents_document_type_configurations_type_id foreign KEY (type_id) references document_type_configurations (id) on delete RESTRICT
);

create table document_fields (
    id uuid not null primary key,
    document_id uuid not null,
    type_id uuid not null,
    value text not null,
    constraint fk_document_fields_documents_document_id foreign KEY (document_id) references documents (id) on delete RESTRICT,
    constraint fk_document_fields_document_field_configurations_type_id foreign KEY (type_id) references document_field_configurations (id) on delete RESTRICT
);

create table document_pages (
    id uuid not null primary key,
    document_id uuid not null,
    type_id uuid not null,
    file_id uuid not null,
    constraint fk_document_pages_documents_document_id foreign KEY (document_id) references documents (id) on delete RESTRICT,
    constraint fk_document_pages_document_page_configurations_type_id foreign KEY (type_id) references document_page_configurations (id) on delete RESTRICT
);
